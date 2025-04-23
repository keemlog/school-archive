package sec03;

public class Rectangle {

	int width;
	int height;
	
	void setWidth(int width) {
		this.width = width;
	}
	
	void setHeight(int height) {
		this.height = height;
	}
	
	void getArea() {
		System.out.println("너비는 " + width + "과 높이는 " + height + "를 가지는 사각형의 면적은 " + width*height + "입니다.");
	}
	
	public static void main(String[] args) {
		Rectangle rect1 = new Rectangle();
		rect1.setWidth(3);
		rect1.setHeight(5);
		rect1.getArea();
		
	}
}
