package weinberg;

import java.io.*;
import java.sql.*;
import java.util.*;

import javax.servlet.*;
import javax.servlet.http.*;
import weinberg.beans.*;

public class Search extends HttpServlet {
	
	private static final long serialVersionUID = 1L;
	
	private Book book;
	private Connection connection;
	private HttpSession httpSession;
	private RequestDispatcher requestDispatcher;
	private ResultSet resultSet;
	private ServletContext servletContext;
	private Statement statement;
	private String searchQuery, criteria;
	private String query;
	
	public ArrayList<Book> bookList;
	
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request, response);
	}
	
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws  ServletException, IOException {		
		criteria = request.getParameter("criteria");
		searchQuery = request.getParameter("searchQuery");
		
		switch(criteria) {
			case "author":
				query = "SELECT * FROM BOOKS WHERE AuthorLName='" + searchQuery + "';";
				break;
				
			case "volumeTitle":
				query = "SELECT * FROM BOOKS WHERE Title='" + searchQuery + "';";
				break;
				
			case "isbn":
				query = "SELECT * FROM BOOKS WHERE ISBN='" + searchQuery + "';";
				break;
		}
		
		try {
			Class.forName("org.postgresql.Driver");
			
			connection = DriverManager.getConnection("jdbc:postgresql://127.0.0.1:5432/postgres", "postgres", "");
			statement = connection.createStatement();
			resultSet = statement.executeQuery(query);
			
			bookList = new ArrayList<Book>();
			
			while (resultSet.next()) {
				book = new Book();
				
				book.setISBN(resultSet.getString("ISBN"));
				book.setTitle(resultSet.getString("Title"));
				book.setDescription(resultSet.getString("Description"));
				book.setEdition(resultSet.getString("Edition"));
				book.setAuthorFName(resultSet.getString("AuthorFName"));
				book.setAuthorLName(resultSet.getString("AuthorLName"));
				book.setCoverArt(resultSet.getString("CoverArt"));
				book.setPrice(resultSet.getFloat("Price"));
				book.setPromotionID(resultSet.getInt("PromotionID"));
				
				bookList.add(book);
			}
			
			connection.close();
		}
		
		catch (Exception e) {
			e.printStackTrace();
		}
		
		httpSession = request.getSession();
		httpSession.setAttribute("search", this);
		
		servletContext = getServletContext();
		
		requestDispatcher = servletContext.getRequestDispatcher("/jsp/search-results.jsp");
		requestDispatcher.forward(request, response);
	}
}
