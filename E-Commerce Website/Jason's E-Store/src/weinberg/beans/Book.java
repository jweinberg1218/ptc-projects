package weinberg.beans;

public class Book {
	
	private String isbn;
	private String title;
	private String description;
	private String edition;
	private String authorFName;
	private String authorLName;
	private String coverArt;
	private float price;
	private int promotionID;
	
	public void setISBN(String isbn) {
		this.isbn = isbn;
	}
	
	public void setTitle(String title) {
		this.title = title;
	}
	
	public void setDescription(String description) {
		this.description = description;
	}
	
	public void setEdition(String edition) {
		this.edition = edition;
	}
	
	public void setAuthorFName(String authorFName) {
		this.authorFName = authorFName;
	}
	
	public void setAuthorLName(String authorLName) {
		this.authorLName = authorLName;
	}
	
	public void setCoverArt(String coverArt) {
		this.coverArt = coverArt;
	}
	
	public void setPrice(float price) {
		this.price = price;
	}
	
	public void setPromotionID(int promotionID) {
		this.promotionID = promotionID;
	}
	
	public String getISBN() {
		return isbn;
	}
	
	public String getTitle() {
		return title;
	}
	
	public String getDescription() {
		return description;
	}
	
	public String getEdition() {
		return edition;
	}
	
	public String getAuthorFName() {
		return authorFName;
	}
	
	public String getAuthorLName() {
		return authorLName;
	}
	
	public String getCoverArt() {
		return coverArt;
	}
	
	public float getPrice() {
		return price;
	}
	
	public int getPromotionID() {
		return promotionID;
	}
}
