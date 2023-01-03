import { deleteSelectedEmployee } from '../functions/http'
import React, { useContext } from 'react'
import { EmployeeContext } from '../context/EmployeeContext'
import { useNavigate, useState, useEffect } from 'react-router-dom'
import '../styles/Form.css';

export default function EmployeeTable({ heading, employees }) {

    const context = useContext(EmployeeContext)
    const navigate = useNavigate()
    const deleteEmployee = (id) => {
        if(window.confirm("Silmek İstediğinize Emin Misiniz")){
            try {
                deleteSelectedEmployee(id) 
                context.deleteEmployee(id) 
    
            } catch (error) {
                alert(error)
            }
        }
        }
    const updateEmployee = (id) => {
        navigate("/employee/update/:" + id, {
            state: { id: id }
        })
    }
    var render = employees.map((e) => {
        return (
            <tr className="table-td"key={e.id}>
                <td>{e.name}</td>
                <td>{e.surname}</td>
                <td>{e.gender}</td>
                <td>{e.graduatedSchool}</td>
                <td>{e.employeeDebits.map((item,index)=>{
                    return(
                        <div key={index}>
                           {item.debit.name}
                        </div>
                    )
                })}</td>
                <td><button className="btn btn-success" onClick={() => updateEmployee(e.id)}>Güncelle</button>
                </td>
                <td><button className="btn btn-danger" onClick={() => deleteEmployee(e.id)}>Sil</button>
                </td>
            </tr>
        )
    })
    return (
        <>
            <div className="magic-form">
                <div className='row'>
                    <div className='col-md-5'>
                        <h4>{heading}</h4>
                        <table className='table table-hover'>
                            <thead>
                                <tr>
                                    <th>Adı</th>
                                    <th>Soyadı</th>
                                    <th>Cinsiyet</th>
                                    <th>Mezun Olduğu Okul</th>
                                    <th>Zimmet</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {render}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </>
    )
}