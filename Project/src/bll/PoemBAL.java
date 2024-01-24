
package bll;

import dal.PoemDAL;

public class PoemBAL {
    private PoemDAL poemDAL;

    public PoemBAL() {
        poemDAL = new PoemDAL();
    }

    public void addPoem(String bookTitle, String bookID, String poemName, String poemData) {
        poemDAL.addPoem(bookTitle, bookID, poemName, poemData);
    }

    public void deletePoem(String poemName) {
        poemDAL.deletePoem(poemName);
    }

    public void updatePoem(String bookTitle, String bookID, String poemName, String poemData) {
        poemDAL.updatePoem(bookTitle, bookID, poemName, poemData);
    }

    public void importPoemFromTxt(String poemName, String poemData) {
        poemDAL.importPoemFromTxt(poemName, poemData);
    }

    public String getPoemData(String poemName) {
        return poemDAL.getPoemData(poemName);
    }
}
