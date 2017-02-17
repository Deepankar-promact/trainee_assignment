struct Employee{
	var employeeName : String
	
	var employeeId : Int
	
	var name : String {
		get{
			return employeeName
		}
		set(empName){
			employeeName = empName
		}
	}
	
	var id : Int {
		get{
			return employeeId
		}
		set(empId){
			employeeId = empId
		}
	}
}

struct EmployeeAdmin{
	var employeeArray = [Employee]()
	
	mutating func addEmployee(employee : Employee){
		
		var employeeVerification : Bool = true
		
		for emp in employeeArray {
			if emp.id == employee.id{
				print("Employee ID exist");
				employeeVerification = false
				break
			}
		}
		
		if employeeVerification {
			employeeArray.append(employee)
			print("Employee Added\n")
		}
	}
	
	mutating func removeEmployee(empID : Int){
		
		var index : Int = 0
		
		for emp in employeeArray {
			
			if emp.id == empID { 
				employeeArray.remove(at: index)
				print("Employee with id is removed")
				break
			}
			
			index += 1
		}
		
	}
	
}

//driver program
print("Hello")

var emp1 = Employee(employeeName: "emp1", employeeId: 1)
var emp2 = Employee(employeeName: "emp2", employeeId: 2)
var emp3 = Employee(employeeName: "emp3", employeeId: 3)
var emp4 = Employee(employeeName: "emp4", employeeId: 1)

var empAdmin = EmployeeAdmin()
empAdmin.addEmployee(employee: emp1)
empAdmin.addEmployee(employee: emp2)
empAdmin.addEmployee(employee: emp3)
empAdmin.addEmployee(employee: emp4)
empAdmin.removeEmployee(empID: 1)



