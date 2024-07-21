import React, { useState, useEffect } from 'react';
import performanceService from '../services/performanceService';

const PerformanceReview = () => {
  const [reviews, setReviews] = useState([]);

  useEffect(() => {
    const fetchReviews = async () => {
      const data = await performanceService.getAllPerformanceReviews();
      setReviews(data);
    };
    fetchReviews();
  }, []);

  return (
    <div>
      <h1>Performance Reviews</h1>
      <table>
        <thead>
          <tr>
            <th>Employee</th>
            <th>Reviewer</th>
            <th>Rating</th>
            <th>Comments</th>
          </tr>
        </thead>
        <tbody>
          {reviews.map((review) => (
            <tr key={review.id}>
              <td>{review.employeeName}</td>
              <td>{review.reviewerName}</td>
              <td>{review.rating}</td>
              <td>{review.comments}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default PerformanceReview;
