package bll;

import java.sql.SQLException;
import java.util.List;

import dal.RootDAL;

public class RootBAL {
	private RootDAL rootDAL;

	public RootBAL() {
		rootDAL = new RootDAL();
	}

	public void addRoot(String root) throws SQLException {
		rootDAL.addRoot(root);
	}

	public List<String> getRoots() {
		return rootDAL.getRoots();
	}

	public void updateRoot(String oldRoot, String newRoot) {
		rootDAL.updateRoot(oldRoot, newRoot);
	}

	public void deleteRoot(String root) {
		rootDAL.deleteRoot(root);
	}
}