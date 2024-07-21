import React, { useEffect, useState } from 'react';
import employeeService from '../services/employeeService';
import leaveRequestService from '../services/leaveRequestService';
import performanceService from '../services/performanceService';

const Dashboard = () => {
  const [employeeCount, setEmployeeCount] = useState(0);
  const [pendingLeaveRequests, setPendingLeaveRequests] = useState(0);
  const [recentPerformanceReviews, setRecentPerformanceReviews] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const employees = await employeeService.getAllEmployees();
      setEmployeeCount(employees.length);

      const leaveRequests = await leaveRequestService.getPendingLeaveRequests();
      setPendingLeaveRequests(leaveRequests.length);

      const performanceReviews = await performanceService.getRecentPerformanceReviews();
      setRecentPerformanceReviews(performanceReviews);
    };

    fetchData();
  }, []);

  return (
    <div>
      <h1>Dashboard</h1>
      <div>
        <h2>Overview</h2>
        <p>Total Employees: {employeeCount}</p>
        <p>Pending Leave Requests: {pendingLeaveRequests}</p>
        <h3>Recent Performance Reviews</h3>
        <ul>
          {recentPerformanceReviews.map(review => (
            <li key={review.id}>
              {review.employeeName}: {review.rating}
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Dashboard;
