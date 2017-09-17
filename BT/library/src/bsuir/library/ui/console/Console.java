package bsuir.library.ui.console;
import bsuir.library.ui.*;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.Properties;

import bsuir.library.dao.*;
public class Console extends ui {
	
	public Console() throws FileNotFoundException {
		
		Properties message = new Properties(); 
		FileInputStream stream = new FileInputStream("c:/_git/BT/src/library/property/MessageProperty.property");
		try {
			message.load(stream);
		}
		catch(Exception str)
		{
			
		}
		//message.load(new java.io.FileInputStream("c:/_git/BT/src/library/property/MessageProperty.property"));
	}
	@Override
	public void Start() {
		// TODO Auto-generated method stub
		Show();
	}

	@Override
	public void Show() {
		// TODO Auto-generated method stub
		ShowMenu();
	}
	public void ShowMenu() {
		//sSystem.out.println(message.getProperty());
		///
	}
	public void SelectAction(int action) {
		switch(action) {
		case 1:
			Dao.ShowListBook();
		case 2: 
			Dao.authentication(inputString("login"), inputString("password"));
			
		}
	}
	private Dao Dao = new Dao();
	private Properties message;
	private String inputString (String message) {
		String resultString="test";
		System.out.println(message);
		//entering string
		return resultString;
	}
}
