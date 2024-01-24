package dal.impl;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashMap;
import java.util.Map;

import dal.IBook;

public class BookDAO implements IBook {
	private static final String DB_URL = "jdbc:mysql://localhost:3306/23fall_missingbooksfinder";
	private static final String DB_USER = "root";
	private static final String DB_PASSWORD = "";

	
	@Override
	public Map<String, Boolean> getAllBooksInSeries(String seriesName) {
		Map<String, Boolean> booksInSeries = new HashMap<>();

		try {
			Connection connection = DriverManager.getConnection(DB_URL, DB_USER, DB_PASSWORD);

			String sql = "SELECT b.name AS book_name, b.is_missing "
					+ "FROM book_series bs INNER JOIN books b ON bs.id = b.series_id "
					+ "WHERE bs.name = ?"
					+ "ORDER BY b.id";
			PreparedStatement preparedStatement = connection.prepareStatement(sql);
			preparedStatement.setString(1, seriesName);

			ResultSet resultSet = preparedStatement.executeQuery();

			while (resultSet.next()) {
				String bookName = resultSet.getString("book_name");
				boolean isMissing = resultSet.getBoolean("is_missing");
				booksInSeries.put(bookName, isMissing);
			}

			resultSet.close();
			preparedStatement.close();
			connection.close();
		} catch (SQLException e) {
			e.printStackTrace();
		}

		return booksInSeries;
	}
}
