package bll;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import dal.IDALFascade;
   
public class BookBO 
{
	private IDALFascade dal;

	public BookBO(IDALFascade dal) {
		this.dal = dal;
	}
    public List<String> getMissingBooks(String series) {
        List<String> missingBooks = new ArrayList<>();

        Map<String, Boolean> allBooksInSeries = dal.getAllBooksInSeries(series);
        for (Map.Entry<String, Boolean> entry : allBooksInSeries.entrySet()) {
            String book = entry.getKey();
            boolean isMissing = entry.getValue();

            if (isMissing) {
            	missingBooks.add(book);
            }
        }
        return missingBooks;
    }
    public ArrayList<String> getOverdueBooks() {
    	return null;
    }
}
