package weinberg;

import java.io.*;
import java.sql.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class Register extends HttpServlet {
	
	private static final long serialVersionUID = 1L;
	
	private Connection connection;
	private RequestDispatcher requestDispatcher;
	private ResultSet resultSet;
	private ServletContext servletContext;
	private Statement statement;
	private String emailAddress, password;
	private String query, update;
	private String loginSuccessful, loginUnsuccessful;
	
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request, response);
	}
	
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws  ServletException, IOException {
		emailAddress = request.getParameter("emailAddress");
		password = request.getParameter("password");
		
		loginSuccessful = "/index.jsp";
		loginUnsuccessful = "/jsp/register.jsp";
		
		query = "SELECT * FROM CUSTOMERS;";
		update = "INSERT INTO CUSTOMERS VALUES ('" + emailAddress + "', '" + password + "');";
		
		servletContext = getServletContext();
		
		try {
			Class.forName("org.postgresql.Driver");
			
			connection = DriverManager.getConnection("jdbc:postgresql://127.0.0.1:5432/postgres", "postgres", "");
			statement = connection.createStatement();
			resultSet = statement.executeQuery(query);
			
			while (resultSet.next()) {
				if (resultSet.getString("EmailAddress").equalsIgnoreCase(emailAddress)) {
					requestDispatcher = servletContext.getRequestDispatcher(loginUnsuccessful);
					requestDispatcher.forward(request, response);
					return;
				}
			}
			
			statement.executeUpdate(update);
			
			requestDispatcher = servletContext.getRequestDispatcher(loginSuccessful);
			requestDispatcher.forward(request, response);
			
			connection.close();
		}
		
		catch (Exception e) {
			e.printStackTrace();
		}
	}
}
