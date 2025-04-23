package sec03;

public class Person {
	String name;
	int age;
	
	void setName(String name) {	// 이름 변경
		this.name = name;
	}
	
	void setAge(int age) {		// 나이 변경
		this.age = age;
	}
	
	String getName() {			// 이름 반환
		return name;
	}
	
	int getAge() {				// 나이 반환
		return age;
	}
		
	public static void main(String[] avgs) {
		Person p1 = new Person();
		p1.setName("홍길동");		// 함수 호출
		p1.setAge(25);
		
		System.out.println("이름 : "+ p1.getName());
		System.out.println("나이 : "+ p1.getAge());
		
		Person p2 = new Person();
		p2.setName("이순신");
		p2.setAge(21);
		
		System.out.println("이름 : "+ p2.getName());
		System.out.println("나이 : "+ p2.getAge());
	}

}

