import React from 'react';
import { Link } from 'react-router-dom';

const Header = () => (
  <header>
    <nav>
      <Link to="/">Home</Link>
      <Link to="/employees">Employees</Link>
      <Link to="/leave-requests">Leave Requests</Link>
      <Link to="/performance-reviews">Performance Reviews</Link>
      <Link to="/reports">Reports</Link>
    </nav>
  </header>
);

export default Header;
