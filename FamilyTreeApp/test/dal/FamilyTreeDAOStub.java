package dal;

import java.util.HashMap;

import dto.PersonDTO;
import dto.PersonData;

public class FamilyTreeDAOStub implements IFamilyTreeDAO {
	
	HashMap<Integer, PersonDTO> dummyDB;
	
	public FamilyTreeDAOStub() {
		
		dummyDB = new HashMap<>();
		
		dummyDB.put(9, new PersonDTO(1, "Ahmad", 9, 10, 11));
		dummyDB.put(10, new PersonDTO(2, "Umar", 10, 12, 13));
		dummyDB.put(11, new PersonDTO(3, "Mumtaz", 11, 14, 15));
	}


	@Override
	public PersonDTO getFatherId(Integer personId) {
		return dummyDB.get(personId);
	}


	@Override
	public PersonDTO getMotherId(Integer personId) {
		return dummyDB.get(personId);
	}
}
