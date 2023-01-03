import { createContext, useReducer } from 'react'

export const EmployeeContext = createContext(
    {
        employees: [],
        sortDesc: (employee) => { },
        deleteBook: (id) => { },
        addEmployee: ({ Name, Surname, Gender, Debit, GraduatedSchool }) => { },
        updateEmployee: ({ Name, Surname, Gender, Debit, GraduatedSchool }) => { },
    }
)

function employeeRecuder(state, action) {
    switch (action.type) {
        case 'SORTD':
            const inverted = action.payload.reverse();
            return inverted;
        case 'ADD':
            return [action.payload, ...state]
        case 'DELETE':
            return state.filter((b) => b.id !== action.payload);
        case 'UPDATE':
            const index = state.findIndex((emp) => emp.id === action.payload.id);
            const updatableEmp = state[index];
            const updatedItem = { ...updatableEmp, ...action.payload.data };
            const updatedEmps = [...state];
            updatedEmps[index] = updatedItem;
            return updatedEmps;
        default:
            return state
    }
}

function EmployeeProvider({ children }) {
    const [employeeState, dispatch] = useReducer(employeeRecuder, [])

    function sortDesc(schoolData) {
        dispatch({ type: 'SORTD', payload: schoolData });
    }
    function addEmployee(employee) {
        dispatch({ type: 'ADD', payload: employee })
    }

    function deleteEmployee(id) {
        dispatch({ type: 'DELETE', payload: id });
    }

    function updateEmployee(id, empData) {
        dispatch({ type: 'UPDATE', payload: { id: id, data: empData } });
    }

    const value = {
        employees: employeeState,
        sortDesc: sortDesc,
        deleteEmployee: deleteEmployee,
        addEmployee: addEmployee,
        updateEmployee: updateEmployee,
    }
    return (
        <EmployeeContext.Provider value={value}>
            {children}
        </EmployeeContext.Provider>
    )
}

export default EmployeeProvider
