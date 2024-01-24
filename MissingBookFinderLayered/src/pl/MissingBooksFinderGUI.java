package pl;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.SwingUtilities;

import bll.BookBO;
import bll.MemberBO;
import dal.AbstractDALFactory;
import dal.IBook;
import dal.IDALFascade;
import dal.IMember;
import dal.impl.BookDAO;
import dal.impl.DALFacade;

public class MissingBooksFinderGUI extends JFrame {

	private static final long serialVersionUID = -1715101882915748261L;
	private JTextField seriesNameField;
	private JTextArea resultArea;
	private BookBO bookBO;
	private MemberBO memberBO;

	
	public void setBookBO(BookBO bookBO) {
		this.bookBO = bookBO;
	}

	public void setMemberBO(MemberBO memberBO) {
		this.memberBO = memberBO;
	}

	public MissingBooksFinderGUI() {
		setTitle("Missing Books Finder");
		setSize(500, 300);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setLocationRelativeTo(null);

		JPanel mainPanel = new JPanel();
		mainPanel.setLayout(new BorderLayout());

		JPanel inputPanel = new JPanel();
		inputPanel.setLayout(new FlowLayout());

		JLabel seriesNameLabel = new JLabel("Enter Series Name:");
		seriesNameField = new JTextField(20);
		JButton searchButton = new JButton("Search");

		inputPanel.add(seriesNameLabel);
		inputPanel.add(seriesNameField);
		inputPanel.add(searchButton);

		resultArea = new JTextArea(10, 30);
		resultArea.setEditable(false);

		mainPanel.add(inputPanel, BorderLayout.NORTH);
		mainPanel.add(new JScrollPane(resultArea), BorderLayout.CENTER);

		searchButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				String seriesName = seriesNameField.getText();
				if (!seriesName.isEmpty()) {
					searchMissingBooks(seriesName);
				}
			}
		});

		add(mainPanel);
	}

	private void searchMissingBooks(String seriesName) {
		resultArea.setText("");
		List<String> missingBooks = bookBO.getMissingBooks(seriesName);
		if (missingBooks.isEmpty()) {
			resultArea.append("No missing books in the series:");
		} else {
			resultArea.append("Missing books in the series: " + seriesNameField.getText() + "\n");
			for (String missingBook : missingBooks) {
				resultArea.append(missingBook + "\n");
			}
		}
	}

	public static void main(String[] args) {
		IBook bookDAO = AbstractDALFactory.getInstance().getBookDAO();
		IMember memberDAO = AbstractDALFactory.getInstance().getMemberDAO();
		IDALFascade facade = new DALFacade(bookDAO, memberDAO);
		BookBO bookBO = new BookBO(facade);
		MemberBO memberBO = new MemberBO(facade);
		
		MissingBooksFinderGUI pl = new MissingBooksFinderGUI();
		pl.setBookBO(bookBO);
		pl.setMemberBO(memberBO);
		
		SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				pl.setVisible(true);
			}
		});
	}
}
