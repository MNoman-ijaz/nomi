package dal2;

import dal.AbstractDALFactory;
import dal.IBook;
import dal.IMember;

public class TextDALFactory extends AbstractDALFactory {

	@Override
	public IBook getBookDAO() {
		return new BookTextDAO(null); // TODO
	}

	@Override
	public IMember getMemberDAO() {
		return null; // TODO
	}

}
