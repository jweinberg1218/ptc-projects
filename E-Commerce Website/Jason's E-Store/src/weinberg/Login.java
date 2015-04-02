package weinberg;

import java.io.*;
import java.sql.*;
import javax.servlet.*;
import javax.servlet.http.*;
import weinberg.beans.*;

public class Login extends HttpServlet {
	
	private static final long serialVersionUID = 1L;
	
	private Connection connection;
	private Credentials credentials;
	private HttpSession httpSession;
	private RequestDispatcher requestDispatcher;
	private ResultSet resultSet;
	private ServletContext servletContext;
	private Statement statement;
	private String emailAddress, password;
	private String query;
	private String loginSuccessful, loginUnsuccessful;
	
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request, response);
	}
	
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws  ServletException, IOException {
		credentials = new Credentials();
		
		emailAddress = request.getParameter("emailAddress");
		password = request.getParameter("password");
		
		httpSession = request.getSession();
		
		loginSuccessful = "/index.jsp";
		loginUnsuccessful = "/jsp/login.jsp";
		
		query = "SELECT * FROM CUSTOMERS;";
		
		servletContext = getServletContext();
		
		try {
			Class.forName("org.postgresql.Driver");
			
			connection = DriverManager.getConnection("jdbc:postgresql://127.0.0.1:5432/postgres", "postgres", "");
			statement = connection.createStatement();
			resultSet = statement.executeQuery(query);
			
			while (resultSet.next()) {
				if (resultSet.getString("EmailAddress").equalsIgnoreCase(emailAddress)
						&& resultSet.getString("Password").equals(password)) {
					credentials.setEmailAddress(emailAddress);
					
					httpSession.setAttribute("credentials", credentials);
					
					requestDispatcher = servletContext.getRequestDispatcher(loginSuccessful);
					requestDispatcher.forward(request, response);
					
					return;
				}
			}
			
			requestDispatcher = servletContext.getRequestDispatcher(loginUnsuccessful);
			requestDispatcher.forward(request, response);
			
			connection.close();
		}
		
		catch (Exception e) {
			e.printStackTrace();
		}
	}
}
