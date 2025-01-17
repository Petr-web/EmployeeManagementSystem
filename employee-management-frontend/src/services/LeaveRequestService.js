import axios from 'axios';

const API_URL = 'http://localhost:5000/api/leaveApplications';

const getAllLeaveRequests = async () => {
  const response = await axios.get(API_URL);
  return response.data;
};

export default { getAllLeaveRequests };
