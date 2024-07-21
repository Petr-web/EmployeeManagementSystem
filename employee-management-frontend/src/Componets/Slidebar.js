import React from 'react';
import { Link } from 'react-router-dom';

const Sidebar = () => (
  <aside>
    <ul>
      <li><Link to="/">Dashboard</Link></li>
      <li><Link to="/employees">Employees</Link></li>
      <li><Link to="/leave-requests">Leave Requests</Link></li>
      <li><Link to="/performance-reviews">Performance Reviews</Link></li>
      <li><Link to="/reports">Reports</Link></li>
    </ul>
  </aside>
);

export default Sidebar;

