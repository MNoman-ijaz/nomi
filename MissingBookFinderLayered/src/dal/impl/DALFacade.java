package dal.impl;

import java.util.ArrayList;
import java.util.Map;

import dal.IBook;
import dal.IDALFascade;
import dal.IMember;
import transferobjects.MemberTO;

public class DALFacade implements IDALFascade {

	private IBook bookDAO;
	private IMember memberDAO;
	
	public DALFacade(IBook bookDAO, IMember memberDAO) {
		super();
		this.bookDAO = bookDAO;
		this.memberDAO = memberDAO;
	}

	@Override
	public Map<String, Boolean> getAllBooksInSeries(String series) {
		return bookDAO.getAllBooksInSeries(series);
	}

	@Override
	public ArrayList<MemberTO> getActiveMembers() {
		return memberDAO.getActiveMembers();
	}

}
