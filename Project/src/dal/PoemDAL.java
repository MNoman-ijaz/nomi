package dal;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class PoemDAL {
	private static final String URL = "jdbc:mysql://localhost:3306/poem";
	private static final String USERNAME = "root";
	private static final String PASSWORD = "";

	static {
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
	}
//FUNCTION TO ADD POEM TO DATABASE
	public void addPoem(String bookTitle, String bookID, String poemName, String poemData) {
		String query = "INSERT INTO Poemdata (bookTitle, bookID, poemName, poemData) VALUES (?, ?, ?, ?)";
		try (Connection connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
				PreparedStatement preparedStatement = connection.prepareStatement(query)) {

			preparedStatement.setString(1, bookTitle);
			preparedStatement.setString(2, bookID);
			preparedStatement.setString(3, poemName);
			preparedStatement.setString(4, poemData);

			preparedStatement.executeUpdate();

		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
	//FUNCTION TO ADD POEM FROM FILE
	public void importPoemFromTxt(String poemName, String poemData) {
	    // Check if the poem with the given name already exists in the database
	    if (isPoemNameUnique(poemName)) {
	        String query = "INSERT INTO Poemdata (poemName, poemData) VALUES (?, ?)";
	        try (Connection connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
	             PreparedStatement preparedStatement = connection.prepareStatement(query)) {

	            preparedStatement.setString(1, poemName);
	            preparedStatement.setString(2, poemData);
	            preparedStatement.executeUpdate();

	        } catch (SQLException e) {
	            e.printStackTrace();
	        }
	    } else {
	        System.out.println("Duplicate poem title found. Data not inserted.");
	    }
	}

	private boolean isPoemNameUnique(String poemName) {
	    String query = "SELECT COUNT(*) as count FROM Poemdata WHERE poemName = ?";
	    try (Connection connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
	         PreparedStatement preparedStatement = connection.prepareStatement(query)) {

	        preparedStatement.setString(1, poemName);
	        ResultSet rs = preparedStatement.executeQuery();

	        if (rs.next()) {
	            int count = rs.getInt("count");
	            // If count is zero, the poem title is unique
	            return count == 0;
	        }

	    } catch (SQLException e) {
	        e.printStackTrace();
	    }
	    // In case of an exception, assume the title is not unique
	    return false;
	}

	//FUNCTION TO DELETE POEM FROM DATABASE
	public void deletePoem(String poemName) {
		String query = "DELETE FROM Poemdata WHERE poemName = ?";
		try (Connection connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
				PreparedStatement preparedStatement = connection.prepareStatement(query)) {

			preparedStatement.setString(1, poemName);
			preparedStatement.executeUpdate();

		} catch (SQLException e) {
			e.printStackTrace();
		}
	}
	//FUNCTION TO GET POEM DATA FROM DATABASE
	public String getPoemData(String poemName) {
		String query = "SELECT poemData FROM Poemdata WHERE poemName = ?";
		try (Connection connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
				PreparedStatement preparedStatement = connection.prepareStatement(query)) {

			preparedStatement.setString(1, poemName);
			ResultSet rs = preparedStatement.executeQuery();

			if (rs.next()) {
				return rs.getString("poemData");
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}
		return null;
	}

	public void updatePoem(String bookTitle, String bookID, String poemName, String poemData) {
		String query = "UPDATE Poemdata SET bookTitle=?, bookID=?, poemData=? WHERE poemName=?";
		try (Connection connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
				PreparedStatement preparedStatement = connection.prepareStatement(query)) {

			preparedStatement.setString(1, bookTitle);
			preparedStatement.setString(2, bookID);
			preparedStatement.setString(3, poemData);
			preparedStatement.setString(4, poemName);

			preparedStatement.executeUpdate();

		} catch (SQLException e) {
			e.printStackTrace();
		}
	}

	public List<String> getPoemVerses(String poemName) {
		String query = "SELECT poemData FROM Poemdata WHERE poemName = ?";
		List<String> verses = new ArrayList<>();
		try (Connection connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
				PreparedStatement preparedStatement = connection.prepareStatement(query)) {

			preparedStatement.setString(1, poemName);
			ResultSet rs = preparedStatement.executeQuery();

			if (rs.next()) {
				String poemData = rs.getString("poemData");
				String[] lines = poemData.split("\n");
				for (String line : lines) {
					verses.add(line);
				}
			}

		} catch (SQLException e) {
			e.printStackTrace();
		}
		return verses;
	}
}
