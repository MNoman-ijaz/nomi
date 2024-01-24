package dal;

import java.lang.reflect.InvocationTargetException;

public abstract class AbstractDALFactory implements IDALFactory {

	private static IDALFactory instance = null;
	public static final IDALFactory getInstance() {
		if (instance == null) {
			String factoryClassName = System.getProperty("dal.factory");
			try {
				Class<?> clazz = Class.forName(factoryClassName);
				instance = (IDALFactory) clazz.getDeclaredConstructor().newInstance();
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			} catch (InstantiationException e) {
				e.printStackTrace();
			} catch (IllegalAccessException e) {
				e.printStackTrace();
			} catch (IllegalArgumentException e) {
				e.printStackTrace();
			} catch (InvocationTargetException e) {
				e.printStackTrace();
			} catch (NoSuchMethodException e) {
				e.printStackTrace();
			} catch (SecurityException e) {
				e.printStackTrace();
			}
		}		
		return instance;
	}
}
