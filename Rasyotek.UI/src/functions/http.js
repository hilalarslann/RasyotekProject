import axios from "axios";
import GetApi from "../Api/ApiManager";
import apiData from "../AppDatas/ApiDatas";

const url = 'https://localhost:7042/';

export async function getEmployees() {
    const response = await axios.get(url + 'Employee/List');
    const employees = [];
    for (const key in response.data) {
        if (response.data[key].gender == 0) {
            response.data[key].gender = "erkek"
        }
        if (response.data[key].gender == 1) {
            response.data[key].gender = "kadın"
        }
        if (response.data[key].gender == 2) {
            response.data[key].gender = "diğer"
        }
        const empObj = {
            id: response.data[key].id,
            name: response.data[key].name,
            surname: response.data[key].surname,
            gender: response.data[key].gender,
            employeeDebits: response.data[key].employeeDebits,
            graduatedSchool: response.data[key].graduatedSchool
        }

        employees.push(empObj);
    }
    return employees;
}

export async function addEmployee(employee) {
    const response = await axios.post(url + 'Employee/Add', employee);
    const id = response.data.name;
    return id;
}

export async function getSchools() {
    const schools = await GetApi(apiData.getSchoolsUrl);
    return schools;
}

export async function getDebits() {
    const debits = await GetApi(apiData.getDebitsUrl);
    return debits;
}

export async function getEmployeeDebits(id) {
    return axios.get(url+`Debit/GetDebitDetails/${id}`)
}

export function getEmployee(id){
    return axios.get(url+`Employee/GetById/${id}`)
  }

export function deleteSelectedEmployee(id) {
    return axios.delete(url + `Employee/Delete/${id}`)
}

export function updateSelectedEmployee(id, empData) {
    return axios.put(url + `Employee/Update/${id}`, empData)
  }