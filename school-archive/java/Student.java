package sec03;

public class Student {
	
	String name;
	int assignment;
	int exam;
	float score;
	char grade;
	
	void setName(String name) {
		this.name = name;
	}
	
	void setExam(int exam) {
		this.exam = exam;
	}
	
	void setAssignment(int assignment) {
		this.assignment = assignment;
	}
	
	void getGrade() {
		score = (float)((assignment*0.6) + (exam*0.4));
		
		if (score >= 90) grade = 'A';
		else if (score >=80 && score < 90) grade = 'B';
		else if (score >= 70 && score < 80) grade = 'C';
		else if (score >= 60 && score < 70) grade = 'D';
		else grade = 'F';
	}
	
	public static void main(String[] avgs) {
		Student std1 = new Student();
		std1.setName("김나현");
		std1.setAssignment(100);
		std1.setExam(98);
		std1.getGrade();
		
		System.out.println("name : " + std1.name);
		System.out.println("score : " + std1.score);
		System.out.println("grade : " + std1.grade);
	}
}
