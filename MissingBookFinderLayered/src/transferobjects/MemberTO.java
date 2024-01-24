package transferobjects;

import java.util.Date;

public class MemberTO {
	private int membershipId;
	private String name;
	private boolean isActive;
	private Date lastPaid;
	
	public int getMembershipId() {
		return membershipId;
	}
	public void setMembershipId(int membershipId) {
		this.membershipId = membershipId;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public boolean isActive() {
		return isActive;
	}
	public void setActive(boolean isActive) {
		this.isActive = isActive;
	}
	public Date getLastPaid() {
		return lastPaid;
	}
	public void setLastPaid(Date lastPaid) {
		this.lastPaid = lastPaid;
	}
}
