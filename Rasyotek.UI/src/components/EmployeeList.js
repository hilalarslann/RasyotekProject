import React, { useContext, useEffect } from 'react'
import { EmployeeContext } from '../context/EmployeeContext'
import { getEmployees } from '../functions/http'
import EmployeeTable from './EmployeeTable'

export default function EmployeeList() {
    const empContext = useContext(EmployeeContext)
    useEffect(() => {
        async function getAllEmployees() {
            try {
                const employees = await getEmployees()
                empContext.sortDesc(employees)
            } catch (error) {
                console.log(error);
            }
        }
        getAllEmployees()
    }, [])

    return (
        <>
            <EmployeeTable heading={"Personel Listesi"} employees={empContext?.employees} />
        </>
    )
}
