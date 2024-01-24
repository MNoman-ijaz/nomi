package dal;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import DTO.BookDTO;

public class BookDAL {
	private String url;
	private String username;
	private String password;

	public BookDAL(String dbUrl, String dbUsername, String dbPassword) {
		this.url = dbUrl;
		this.username = dbUsername;
		this.password = dbPassword;
	}
	
	//FUNCTION TO CREATE NEW BOOK

	

	public void createBook(BookDTO book) throws SQLException {
	    try (Connection connection = DriverManager.getConnection(url, username, password);
	         PreparedStatement stmt = connection.prepareStatement(
	                 "INSERT INTO bookstable (Title, Author, Year_of_Author_Passing) VALUES (?, ?, ?)",
	                 Statement.RETURN_GENERATED_KEYS)) {

	       
	        stmt.setString(1, book.getTitle());
	        stmt.setString(2, book.getAuthor());
	        stmt.setInt(3, book.getYearOfAuthorPassing());

	       
	        stmt.executeUpdate();
	        
	       
	        try (ResultSet generatedKeys = stmt.getGeneratedKeys()) {
	            if (generatedKeys.next()) {
	                book.setId(generatedKeys.getInt(1));
	            }
	        }
	    }
	  
	}

//TO RETERIEVE ALL BOOKS FROM DATABASE
	public List<BookDTO> getAllBooks() {
		List<BookDTO> books = new ArrayList<>();
		try (Connection conn = DriverManager.getConnection(url, username, password);
				PreparedStatement stmt = conn.prepareStatement("SELECT * FROM bookstable");
				ResultSet rs = stmt.executeQuery()) {
			while (rs.next()) {
				BookDTO book = new BookDTO();
				book.setId(rs.getInt("ID"));
				book.setTitle(rs.getString("Title"));
				book.setAuthor(rs.getString("Author"));
				book.setYearOfAuthorPassing(rs.getInt("Year_of_Author_Passing"));
				books.add(book);
			}
		} catch (SQLException e) {
			System.out.println("Error while fetching all books: " + e.getMessage());
		}
		return books;
	}
//FUNCTION TO MANAGE ID
	private int getNextAvailableBookId() {
		int nextId = 1;
		List<BookDTO> books = getAllBooks();
		for (BookDTO book : books) {
			if (book.getId() >= nextId) {
				nextId = book.getId() + 1;
			}
		}
		return nextId;
	}
//FUNCTION TO ADD UPDATE BOOK IN DATABASE
	public void updateBook(BookDTO updatedBook) {
		try (Connection conn = DriverManager.getConnection(url, username, password);
				PreparedStatement stmt = conn.prepareStatement(
						"UPDATE bookstable SET Title = ?, Author = ?, Year_of_Author_Passing = ? WHERE ID = ?")) {
			stmt.setString(1, updatedBook.getTitle());
			stmt.setString(2, updatedBook.getAuthor());
			stmt.setInt(3, updatedBook.getYearOfAuthorPassing());
			stmt.setInt(4, updatedBook.getId());
			stmt.executeUpdate();
		} catch (SQLException e) {
			System.out.println("Error while updating the book: " + e.getMessage());
		}
	}
	//FUNCTION TO DELETE BOOK IN DATABASE
	public void deleteBook(int bookId) {
		try (Connection conn = DriverManager.getConnection(url, username, password);
				PreparedStatement stmt = conn.prepareStatement("DELETE FROM bookstable WHERE ID = ?")) {
			stmt.setInt(1, bookId);
			stmt.executeUpdate();
		} catch (SQLException e) {
			System.out.println("Error while deleting the book: " + e.getMessage());
		}

		reorganizeBookIds(bookId);
	}

	
	//REORGANIZE BOOK ID IN DATA BASE TABLE
	private void reorganizeBookIds(int deletedBookId) {
		List<BookDTO> books = getAllBooks();
		for (BookDTO book : books) {
			if (book.getId() > deletedBookId) {
				book.setId(book.getId() - 1);
				updateBookIdInDatabase(book.getId(), book.getId() + 1);
			}
		}
	}

	private void updateBookIdInDatabase(int newId, int oldId) {
		try (Connection connection = DriverManager.getConnection(url, username, password);
				PreparedStatement stmt = connection.prepareStatement("UPDATE bookstable SET ID = ? WHERE ID = ?")) {
			stmt.setInt(1, newId);
			stmt.setInt(2, oldId);
			stmt.executeUpdate();
		} catch (SQLException e) {
			System.out.println("Error while updating the book ID in the database: " + e.getMessage());
		}
	}

}
