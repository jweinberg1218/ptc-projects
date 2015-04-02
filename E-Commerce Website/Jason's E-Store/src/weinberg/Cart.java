package weinberg;

import java.io.*;
import java.util.*;
import javax.servlet.*;
import javax.servlet.http.*;
import weinberg.beans.*;

public class Cart extends HttpServlet {

	private static final long serialVersionUID = 1L;

	private HttpSession httpSession;
	private RequestDispatcher requestDispatcher;
	private Search search;
	private ServletContext servletContext;
	
	public ArrayList<Book> bookList;

	public Cart() {
		bookList = new ArrayList<Book>();
	}

	public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		doPost(request, response);
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response) throws  ServletException, IOException {
		httpSession = request.getSession();
		
		search = (Search)httpSession.getAttribute("search");

		for (Book book : search.bookList) {
			if (request.getParameter(book.getISBN()) == "checked")
			{
				bookList.add(book);
			}
		}
		
		httpSession.setAttribute("cart", this);
		
		servletContext = getServletContext();
		
		requestDispatcher = servletContext.getRequestDispatcher("/jsp/cart.jsp");
		requestDispatcher.forward(request, response);
	}
}
