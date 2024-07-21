import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import employeeService from '../services/employeeService';

const EmployeeDetails = () => {
  const { id } = useParams();
  const [employee, setEmployee] = useState(null);

  useEffect(() => {
    const fetchEmployee = async () => {
      const employee = await employeeService.getEmployeeById(id);
      setEmployee(employee);
    };
    fetchEmployee();
  }, [id]);

  if (!employee) return <div>Loading...</div>;

  return (
    <div>
      <h1>Employee Details</h1>
      <p>Name: {employee.firstName} {employee.lastName}</p>
      <p>Email: {employee.email}</p>
      <p>Department: {employee.department}</p>
      <p>Position: {employee.position}</p>
   
    </div>
  );
};

export default EmployeeDetails;
