package bll;                                                                                                                                                            
                                                                                                                                                                        
import dal.IFamilyTreeDAO;                                                                                                                                              
                                                                                                                                                                        
public class FamilyTreeBO {                                                                                                                                             
	                                                                                                                                                                    	
	private IFamilyTreeDAO dao;                                                                                                                                         
                                                                                                                                                                        
    public FamilyTreeBO(IFamilyTreeDAO dao) {                                                                                                                           
        this.dao = dao;                                                                                                                                                 
    }                                                                                                                                                                   
	                                                                                                                                                                    	
	public Boolean isSibling(Integer cnic1, Integer cnic2) {                                                                                                            
		                                                                                                                                                                
		if( dao.getFatherId(cnic1).getFathersCnic() == cnic1 ) {                                                                                                        
			if( dao.getMotherId(cnic2).getMothersCnic() == cnic2 ) {                                                                                                    
				return true;                                                                                                                                            
			}                                                                                                                                                           
		}                                                                                                                                                               
		return false;                                                                                                                                                   
	}                                                                                                                                                                   
	                                                                                                                                                                    	
	public Boolean isHalfSibling(Integer cnic1, Integer cnic2) {                                                                                                        
		                                                                                                                                                                
		if( dao.getFatherId(cnic1).getFathersCnic() == cnic1 ) {                                                                                                        
			return true;                                                                                                                                                
		}                                                                                                                                                               
		if( dao.getMotherId(cnic2).getMothersCnic() == cnic2 ) {                                                                                                        
			return true;	                                                                                                                                            
		}                                                                                                                                                               
		return false;                                                                                                                                                   
	}                                                                                                                                                                   
}                                                                                                                                                                       
                                                                                                                                                                        
