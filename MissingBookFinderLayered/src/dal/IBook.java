package dal;

import java.util.Map;

public interface IBook {
	public Map<String, Boolean> getAllBooksInSeries(String series);
}
