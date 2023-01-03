import Layout from "./components/Layout";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import EmployeeList from "./components/EmployeeList";
import { EmployeePage } from "./components/EmployeePage";
import EmployeeUpdate from "./components/EmployeeUpdate";
import { useState } from 'react'
import axios from 'axios'

function App() {
  // const [loading, setLoading] = useState(false);

  // axios.interceptors.request.use(
  //   (config) => {
  //     setLoading(true);
  //     return config;
  //   },
  //   (error) => {
  //     return Promise.reject(error);
  //   }
  // );


  // axios.interceptors.response.use(
  //   (response) => {
  //     setLoading(false);
  //     return response;
  //   },
  //   (error) => {
  //     return Promise.reject(error);
  //   }
  // );

  return (
    <div className="container-fluid">
      <BrowserRouter>
        <Layout />
        <Routes>
          <Route path="/" element={<EmployeeList />} />
          <Route path="/employee/all" element={<EmployeeList />} />
          <Route path="/employee/add" element={<EmployeePage />} />
          <Route path="/employee/update/:id" element={<EmployeeUpdate />} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App;
