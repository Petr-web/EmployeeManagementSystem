import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import Home from './Pages/Home';
import Employees from './pages/Employees';
import EmployeeDetails from './components/EmployeeDetails';
import LeaveRequests from './pages/LeaveRequests';
import PerformanceReviews from './Pages/PerformanceReviews';
import Reports from './Pages/Reports';

const App = () => (
  <div>
    <Header />
    <Sidebar />
    <main>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/employees" element={<Employees />} />
        <Route path="/employees/:id" element={<EmployeeDetails />} />
        <Route path="/leave-requests" element={<LeaveRequests />} />
        <Route path="/performance-reviews" element={<PerformanceReviews />} />
        <Route path="/reports" element={<Reports />} />
      </Routes>
    </main>
  </div>
);

export default App;
