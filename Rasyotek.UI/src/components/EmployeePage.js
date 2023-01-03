import React, { useEffect, useState } from 'react';
import { Formik, Field } from 'formik';
import * as Yup from 'yup';
import '../styles/Form.css';
import { getSchools, addEmployee, getDebits } from '../functions/http';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom';




export function EmployeePage() {
    const [checkDebit, setCheckDebit] = useState([]);


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
    const navigate = useNavigate();
    const [schools, setSchools] = useState([]);
    useEffect(
        () => {
            getSchools().then(res => setSchools(res));
            if (schools.length == 0) {
                empty = true;
            }
        }, []
    )
    const [debits, setDebits] = useState([]);
    useEffect(
        () => {
            getDebits().then(res => setDebits(res));
        }, []
    )

    return (
        <>
            <div className="container">
                <div>
                    <Formik
                        initialValues={{
                            name: '',
                            surname: '',
                            gender: 0,
                            // debit: 0,
                            graduatedSchool: '',
                        }}
                        validationSchema={Yup.object({
                            name: Yup.string().required('İsim alanı boş bırakılamaz'),
                            surname: Yup.string().required('Soyisim alanı boş bırakılamaz'),
                            // gender: Yup.number().required( 'Cinsiyet alanı boş bırakılamaz'),
                            // debit: Yup.string().required('Zimmet alanı boş bırakılamaz'),
                            graduatedSchool: Yup.string()
                                .required('Lütfen mezun olduğunuz alanı seçiniz')
                        })}
                        onSubmit={async (values, { setSubmitting, resetForm }) => {
                            
                            var data = {
                                name: values.name,
                                surname: values.surname,
                                gender: values.gender,
                                graduatedSchool: values.graduatedSchool,
                                debitIdList : checkDebit.map((item) => item.id)
                            }
                            await addEmployee(data).then((res) => {
                                navigate("/")
                            }).
                                catch((err) => {
                                    console.log(err)
                                })
                        }}>
                        {({
                            values,
                            touched,
                            errors,
                            dirty,
                            isSubmitting,
                            handleSubmit,
                            handleReset,
                            handleChange,
                        }) => (
                            <form className="magic-form" onSubmit={handleSubmit}>
                                <h4>Personel Ekle</h4>
                                <label htmlFor="name">İsim</label>
                                <input
                                    id="name"
                                    type="text"
                                    placeholder="İsim giriniz.."
                                    className="input"
                                    value={values.name}
                                    onChange={handleChange}
                                />
                                {errors.name && touched.name && (
                                    <div className="input-feedback">{errors.name}</div>
                                )}
                                <label htmlFor="surname">Soyisim</label>
                                <input
                                    id="surname"
                                    type="text"
                                    placeholder="Soyisim giriniz.."
                                    className="input"
                                    value={values.surname}
                                    onChange={handleChange}
                                />
                                {errors.surname && touched.name && (
                                    <div className="input-feedback">{errors.surname}</div>
                                )}

                                <label htmlFor="gender">Cinsiyet</label>
                                <div>
                                    <input type="radio" name="gender" value={0} onChange={handleChange} />
                                    <label className="checkbox-label">
                                        Erkek
                                    </label>
                                    <input type="radio" name="gender" value={1} onChange={handleChange} />
                                    <label className="checkbox-label">
                                        Kadın
                                    </label>
                                    <input type="radio" name="gender" value={2} onChange={handleChange} />
                                    <label className="checkbox-label">
                                        Diğer
                                    </label>
                                </div>
                                {errors.gender && (
                                    <div className="input-feedback">{errors.gender}</div>
                                )}

                                <label htmlFor="debit">Zimmetleriniz</label>
                                <div className="checkbox">
                                    <div role="group" aria-labelledby="checkbox-group" >
                                        {debits.map((debit, index) => {
                                            return (
                                                <label className="checkbox-label" key={index} >
                                                    <input type="checkbox" name={debit.name} onChange={(e) => {
                                                        
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
                                    </div></div>
                                {errors.debit && touched.debit && (
                                    <div className="input-feedback">{errors.debit}</div>
                                )}

                                <label className="topMargin">
                                    Mezun Olduğunuz Okul
                                </label>
                                <select id="graduatedSchool" value={values.graduatedSchool} onChange={handleChange} onClick={notify} >
                                    <option>Lütfen okul seçiniz...</option>
                                    {schools.map((school, index) => {
                                        return (
                                            <option key={index}>{school.name}</option>
                                        )
                                    })}
                                </select>

                                {errors.graduatedSchool && touched.graduatedSchool && (
                                    <div className="input-feedback">{errors.graduatedSchool}</div>
                                )}

                                <button type="submit">
                                    Ekle
                                </button>
                                <ToastContainer
                                    className="toast-position"
                                    position="top-center"
                                    hideProgressBar={false}
                                    newestOnTop={false}
                                    autoClose={false}
                                    rtl={false}
                                />
                            </form>
                        )}
                    </Formik>
                </div>
            </div >
        </>
    );
};
