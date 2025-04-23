package sec03;

public class Dog {
	
	String name;
	String breeds;
	int age;
	
	void setName(String name) {
		this.name = name;
	}
	
	void setBreeds(String breeds) {
		this.breeds = breeds;
	}
	
	void setAge(int age) {
		this.age = age;
	}
	
	void bark() {
		System.out.println("["+ name + "] 멍멍!");
	}
	
	void action() {
		System.out.println("["+ name + "] 살랑살랑!");
	}
	
	public static void main(String[] avgs) {
		Dog d1 = new Dog();
		d1.setName("망고");
		d1.setBreeds("골든리트리버");
		d1.setAge(2);
		
		Dog d2 = new Dog();
		d2.setName("까미");
		d2.setBreeds("믹스");
		d2.setAge(3);
		
		System.out.println("name: " + d1.name);
		System.out.println("breeds: " + d1.breeds);
		System.out.println("age: " + d1.age);
		System.out.println();
		
		System.out.println("name: " + d2.name);
		System.out.println("breeds: " + d2.breeds);
		System.out.println("age: " + d2.age);
		System.out.println();
		
		d1.action();
		d2.bark();
	}

	
}
