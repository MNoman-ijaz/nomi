package bll;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;
import static org.junit.jupiter.api.Assertions.*;

import org.junit.Before;
import org.junit.Test;

import dal.FamilyTreeDAOStub;
import dal.IFamilyTreeDAO;


public class FamilyTreeBOTest {			

    static IFamilyTreeDAO genealogyDao;
    static FamilyTreeDAOStub manager;

    @Before
    static void setUp() {
        genealogyDao = new IFamilyTreeDAO();
        manager = new GenealogyManager(genealogyDao);
    }

    @Test
    @DisplayName("Test areCousins method - Edge Coverage")
    public void testAreCousinsEdgeCoverage() {
        boolean areCousinsScenario1 = manager.areCousins(10, 11);
        assertEquals(areCousinsScenario1, "Expected to be cousins but they are not.");

        boolean areCousinsScenario2 = manager.areCousins(12, 11);
        assertFalse(areCousinsScenario2, "Expected not to be cousins.");

        boolean areCousinsScenario3 = manager.areCousins(10, 13);
        assertFalse(areCousinsScenario3, "Expected not to be cousins.");

        boolean areCousinsScenario4 = manager.areCousins(14, 15);
        assertFalse(areCousinsScenario4, "Expected not to be cousins.");
    }
    
    
    @Test
    @DisplayName("Test areHalfCousins method - Edge Coverage")
    public void testAreHalfCousinsEdgeCoverage() {
    	
        boolean areHalfCousinsScenario1 = manager.areHalfCousins(12, 11);
        assertTrue(areHalfCousinsScenario1, "Expected to be half cousins.");

        boolean areHalfCousinsScenario2 = manager.areHalfCousins(10, 13);
        assertTrue(areHalfCousinsScenario2, "Expected to be half cousins.");

        boolean areHalfCousinsScenario3 = manager.areHalfCousins(12, 14);
        assertFalse(areHalfCousinsScenario3, "Expected not to be half cousins.");

        boolean areHalfCousinsScenario4 = manager.areHalfCousins(10, 13);
        assertTrue(areHalfCousinsScenario4, "Expected to be half cousins.");

        boolean areHalfCousinsScenario5 = manager.areHalfCousins(14, 15);
        assertFalse(areHalfCousinsScenario5, "Expected not to be half cousins.");
    }
}
