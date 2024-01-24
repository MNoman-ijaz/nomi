package dal;

public interface IDALFactory {
	public IBook getBookDAO();
	public IMember getMemberDAO();
	
}
