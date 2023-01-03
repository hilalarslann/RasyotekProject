import React, { useState, useEffect } from 'react'
import { getEmployee, updateSelectedEmployee, getDebits } from '../functions/http'
import { useLocation } from 'react-router-dom'
import { useNavigate } from 'react-router-dom';
import { useContext } from 'react';
import { EmployeeContext } from '../context/EmployeeContext';
import { getSchools } from '../functions/http';
import { ToastContainer, toast } from 'react-toastify';
import { Formik, Field } from 'formik';
import 'react-toastify/dist/ReactToastify.css';
import '../styles/Form.css';

export default function EmployeeUpdate() {
    const [checkDebit, setCheckDebit] = useState([]);
    const context = useContext(EmployeeContext)
    const location = useLocation()
    const navigate = useNavigate()
    const [selectedEmp, setSelectedEmp] = useState({
        name: "",
        surname: "",
        gender: 0,
        debit: false,
        graduatedSchool: "",
        debitIdList: {checkDebit}
    });

    const [debits, setDebits] = useState([]);


    useEffect(() => {
        getDebits().then(res => setDebits(res))
        getEmployee(location.state.id).then((res) => {
            setSelectedEmp(res.data)
            setCheckDebit(res.data.employeeDebits.map((item) => item.debit.id))
        })
    }, [])

    const updateEmployee = () => {
        try {
            updateSelectedEmployee(location.state.id, selectedEmp);
            alert("Güncellendi")
            navigate("/")
            window.location.reload(true)

        } catch (error) {
            alert(error)
        }
    }

    const onChangeText = (event) => {
        setSelectedEmp({ ...selectedEmp, [event.target.name]: event.target.value })
    }
    var empty = false;
    if (!empty) {
        toast.dismiss();
    }
    const notify = () => {
        if (empty == true) {
            toast.dismiss();
            toast("Lütfen bekleyiniz");
        }
        else {
            empty = false;
        }
    }
    const [schools, setSchools] = useState([]);
    useEffect(
        () => {
            getSchools().then(res => setSchools(res));
            if (schools.length == 0) {
                empty = true;
            }
        }, []
    )
    return (
        <>
            <div className="container">
                <div>
                    <Formik>
                        <form className="magic-form">
                            <h4>Personel Güncelle</h4>
                            <label>İsim</label>
                            <input
                                className="form-control"
                                type="text"
                                name="name"
                                value={selectedEmp.name}
                                onChange={onChangeText}
                            />

                            <label htmlFor="surname">Soyisim</label>
                            <input
                                type="text"
                                className="input"
                                name="surname"
                                value={selectedEmp.surname}
                                onChange={onChangeText}
                            />

                            <label htmlFor="gender">Cinsiyet</label>
                            <div>
                                <input type="radio" name="gender" value={0} onChange={onChangeText} />
                                <label className="checkbox-label" >
                                    Erkek
                                </label>
                                <input type="radio" name="gender" value={1} onChange={onChangeText} />
                                <label className="checkbox-label">
                                    Kadın
                                </label>
                                <input type="radio" name="gender" value={2} onChange={onChangeText} />
                                <label className="checkbox-label">
                                    Diğer
                                </label>
                            </div>
{/* 
                            <label htmlFor="debit">Zimmetleriniz</label>
                            <div className="checkbox">
                                <div role="group" aria-labelledby="checkbox-group" >
                                    {debits.map((debit, index) => {
                                        return (
                                            <label className="checkbox-label" key={index} >
                                                <input type="checkbox" name="debitIdList" defaultChecked={checkDebit.includes(debit.id)} onChange={(e) => {

                                                    if (e.target.checked) {
                                                        setCheckDebit([
                                                            ...checkDebit,
                                                            {
                                                                id: debit.id
                                                            },
                                                        ]);
                                                    }
                                                    else {
                                                        setCheckDebit(
                                                            checkDebit.filter((data) => data.id !== debit.id),
                                                        );
                                                    }
                                                }} />
                                                {debit.name}
                                            </label>
                                        )
                                    })}
                                </div></div> */}


                            <label className="topMargin">
                                Mezun Olduğunuz Okul
                            </label>
                            <select id="graduatedSchool" name="graduatedSchool" value={selectedEmp.graduatedSchool} onChange={onChangeText}>
                                <option>Lütfen okul seçiniz...</option>
                                {schools.map((school, index) => {
                                    return (
                                        <option key={index}>{school.name}</option>
                                    )
                                })}
                            </select>

                            <input className="btn btn-success" type="submit" value="Güncelle"
                                onClick={() => updateEmployee()} />
                            <ToastContainer
                                className="toast-position"
                                position="top-center"
                                hideProgressBar={false}
                                newestOnTop={false}
                                autoClose={false}
                                rtl={false}
                            />
                        </form>
                    </Formik>
                </div>
            </div >
        </>
    )
}
