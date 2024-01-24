package dal.impl;

import dal.AbstractDALFactory;
import dal.IBook;
import dal.IMember;

public class MySqlDALFactory extends AbstractDALFactory {

	@Override
	public IBook getBookDAO() {
		return new BookDAO();
	}

	@Override
	public IMember getMemberDAO() {
		return new MemberDAO();
	}

}