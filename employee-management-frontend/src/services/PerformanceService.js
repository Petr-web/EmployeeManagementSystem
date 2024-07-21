import axios from 'axios';

const API_URL = 'http://localhost:5000/api/performance';

const getAllPerformanceReviews = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export default { getAllPerformanceReviews };
