package bll;

import java.sql.SQLException;
import java.util.List;

import DTO.BookDTO;
import dal.BookDAL;

public class BookBAL {
    private BookDAL bookDAL;

    public BookBAL(String dbUrl, String dbUsername, String dbPassword) {
        bookDAL = new BookDAL(dbUrl, dbUsername, dbPassword);
    }

    public void createBook(BookDTO book) throws SQLException {
        bookDAL.createBook(book);
    }

    public List<BookDTO> getAllBooks() {
        return bookDAL.getAllBooks();
    }

    public void updateBook(BookDTO updatedBook) {
        bookDAL.updateBook(updatedBook);
    }

    public void deleteBook(int bookId) {
        bookDAL.deleteBook(bookId);
    }

}