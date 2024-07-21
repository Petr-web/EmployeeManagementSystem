import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import employeeService from '../services/employeeService';

const EmployeeList = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    const fetchEmployees = async () => {
      const employees = await employeeService.getAllEmployees();
      setEmployees(employees);
    };
    fetchEmployees();
  }, []);

  return (
    <div>
      <h1>Employees</h1>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Department</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((employee) => (
            <tr key={employee.id}>
              <td>
                <Link to={`/employees/${employee.id}`}>
                  {employee.firstName} {employee.lastName}
                </Link>
              </td>
              <td>{employee.email}</td>
              <td>{employee.department}</td>
              <td>
                <Link to={`/employees/${employee.id}/edit`}>Edit</Link>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default EmployeeList;
