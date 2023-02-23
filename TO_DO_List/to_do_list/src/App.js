import React, { useEffect, useState } from 'react';
import { Table, Button, Modal, Input, Form, Checkbox } from 'antd';
//import 'antd/dist/antd.css';
import "./App.css";
import axios from "axios";

const { Item } = Form;
const urlGetAll = "http://localhost:58804/api/ToDoList/GetAllTask";
const urlAddTask = "http://localhost:58804/api/ToDoList/AddTask";
const urlDescrTask = "http://localhost:58804/api/ToDoList/UpdateDescriptionTask";
const urlStatusTask = "http://localhost:58804/api/ToDoList/UpdateStatusTask";
const urlDeleteTask = "http://localhost:58804/api/ToDoList/DeletTask"

const layout = {
    labelCol: {
        span: 8
    },
    wrapperCol: {
        span: 16
    }
};

function App() {

    const [data, setData] = useState([]);
    const [modalEditar, setModalEditar] = useState(false);
    const [modalEliminar, setModalEliminar] = useState(false);
    const [tarea, setTarea] = useState({
        idTask: '',
        descriptionTask: '',
        idEstatusTask: ''
    })
    const [checked, setChecked] = useState(true);
    const abrirCerrarModalEditar = () => {
        setModalEditar(!modalEditar);
    }

    const abrirCerrarModalEliminar = () => {
        setModalEliminar(!modalEliminar);
    }

    const [description, setDescription] = useState(""); // (F-1)

    const seleccionarTarea = (tarea, caso) => {
        setTarea(tarea);
        (caso === "Editar") ? abrirCerrarModalEditar() : abrirCerrarModalEliminar()
    }

    const handleChange = e => {
        const { name, value } = e.target;
        setTarea({
            ...tarea,
            [name]: value
        });
        console.log(tarea);
    }

    const onChange = (e) => {
        console.log('checked = ', e.target.checked);
        setChecked(e.target.checked);
    };

    const columns = [
        {
            title: "Done",
            dataIndex: "idEstatusTask",
            key: "idEstatusTask",
            render: (fila) => (
                <>
                    <Checkbox id="idEstatusTask" name="idEstatusTask" disabled defaultValue={fila.idEstatusTask === "0" ? false : true} checked={fila.idEstatusTask  === "0" ? false : true} />
                </>
            ),
        },
        {
            title: "Task",
            dataIndex: "descriptionTask",
            key: "descriptionTask"
        },
        {
            title: "Actions",
            key: "acciones",
            render: (fila) => (
                <>
                    <Button type="primary" onClick={() => seleccionarTarea(fila, "Editar")}>Editar</Button> {"   "}
                    <Button type="primary" danger onClick={() => seleccionarTarea(fila, "Eliminar")}>
                        Eliminar
                    </Button>
                </>
            ),
        },

    ];
    const peticionGet = async () => {
        await axios.get(urlGetAll)
            .then(response => {
                setData(response.data);
            }).catch(error => {
                console.log(error);
            })
    }


    const peticionAddTask = async () => {
        delete tarea.idTask;
        await axios.post(urlAddTask + "?descriptionTask=" + description)
            .then(response => {
                setData(data.concat(response.data));
                setDescription("");
            }).catch(error => {
                console.log(error);
            })
    }

    const peticionUpdateDescrTask = async () => {
        await axios.post(urlDescrTask + '?idTask=' + tarea.idTask + '&descriptionTask=' + tarea.descriptionTask + '&statusTask=' + checked)
            .then(response => {
                var dataAuxiliar = data;
                dataAuxiliar.map(elemento => {
                    if (elemento.idTask === tarea.idTask) {
                        elemento.descriptionTask = tarea.descriptionTask;
                        elemento.idEstatusTask = tarea.idEstatusTask;
                    }
                });
                setData(dataAuxiliar);
                abrirCerrarModalEditar();
            }).catch(error => {
                console.log(error);
            })
    }

    const peticionUpdateStatusTask = async () => {
        await axios.post(urlStatusTask + '?idTask=' + tarea.idTask + '&idStatusTask=' + tarea.idEstatusTask)
            .then(response => {
                var dataAuxiliar = data;
                dataAuxiliar.map(elemento => {
                    if (elemento.idTask === tarea.idTask) {
                        elemento.descriptionTask = tarea.descriptionTask;
                        elemento.idEstatusTask = tarea.idEstatusTask;
                    }
                });
                setData(dataAuxiliar);
                abrirCerrarModalEditar();
            }).catch(error => {
                console.log(error);
            })
    }

    const peticionDelete = async () => {
        await axios.post(urlDeleteTask + "?idTask=" + parseInt(tarea.idTask))
            .then(response => {
                setData(data.filter(elemento => elemento.idTask !== tarea.idTask));
                abrirCerrarModalEliminar();
            }).catch(error => {
                console.log(error);
            })
    }

    useEffect(() => {
        peticionGet();
    }, [])

    return (
        <div className="App">
            <div className="file-input">
                <Input
                    type="text"
                    className="text"
                    value={description}
                    placeholder="Add Task"
                    onChange={e => setDescription(e.target.value)}
                />
                <Button type="primary" className="botonInsertar"
                    disabled={description ? "" : "disabled"}
                    onClick={peticionAddTask}
                >
                    Add
                </Button>
            </div>
            <Table columns={columns} dataSource={data} />

            <Modal
                visible={modalEditar}
                title="Task Edit"
                onCancel={abrirCerrarModalEditar}
                centered
                footer={[
                    <Button onClick={abrirCerrarModalEditar}>Cancelar</Button>,
                    <Button type="primary" onClick={peticionUpdateDescrTask}>Editar</Button>,
                ]}
            >
                <Form {...layout}>
                    <Item label="Status Task">
                        <Checkbox id="idEstatusTask" name="idEstatusTask" defaultValue={tarea && tarea.idEstatusTask === "0" ? false : true} onChange={onChange} checked={checked} />
                    </Item>
                    <Item label="Description Task">
                        <Input type="text" className="text" name="descriptionTask" onChange={handleChange} value={tarea && tarea.descriptionTask} />
                    </Item>
                </Form>
            </Modal>

            <Modal
                visible={modalEliminar}
                onCancel={abrirCerrarModalEliminar}
                centered
                footer={[
                    <Button onClick={abrirCerrarModalEliminar}>No</Button>,
                    <Button type="primary" danger onClick={peticionDelete}>Sí</Button>,
                ]}
            >
                Do you want delete: <b>{tarea && tarea.descriptionTask}</b>?
            </Modal>
        </div>
    );
}

export default App;