package dal2;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import dal.IBook;

public class BookTextDAO implements IBook {
	private String fileName;
	public BookTextDAO(String fileName) {
		this.fileName = fileName;
	}
	
	@Override
	public Map<String, Boolean> getAllBooksInSeries(String series) {
		boolean isMatching = false;
		FileReader fileReader = null;
		BufferedReader bufferedReader = null;
		Map<String, Boolean> booksInSeries = new HashMap<>();

		try {
			fileReader = new FileReader(fileName);
			bufferedReader = new BufferedReader(fileReader);
			String line;
			while ((line = bufferedReader.readLine()) != null) {
				if (line.trim().equals(series)) {
					isMatching = true;
				} else if (line.startsWith("\t") && isMatching) {
					String[] parts = line.trim().split("\t");
					booksInSeries.put(parts[0], Boolean.parseBoolean(parts[1]));
				} else {
					// If a non-matching line is encountered, stop collecting tabbed lines
					isMatching = false;
				}
			}
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			try {
				bufferedReader.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}

		return booksInSeries;
	}
}
