package bll;

import java.util.ArrayList;
import java.util.Date;

import dal.IDALFascade;
import transferobjects.MemberTO;

public class MemberBO {
	private IDALFascade dao;
	public MemberBO(IDALFascade dao) 
	{
		this.dao = dao;
	}
	private int calculateDuration(Date d1, Date d2) {
		return 0; // TODO
	}
	public ArrayList<String> getDefaulters() {
		ArrayList<MemberTO> members = dao.getActiveMembers();
		ArrayList<String> defaulters = new ArrayList<>();
		for (MemberTO mem : members) {
			if (calculateDuration(mem.getLastPaid(), new Date()) > 365 ) 
			
			{
				defaulters.add(mem.getName());
			}
		}
		return defaulters;
	}
}
