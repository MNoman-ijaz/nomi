package dal;

import java.util.ArrayList;

import transferobjects.MemberTO;

public interface IMember {
	public ArrayList<MemberTO> getActiveMembers();
}
