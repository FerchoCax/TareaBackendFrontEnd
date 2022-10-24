<template>
    <div>

            <div class="container izquierda">

                <button class="btn btn-primary" v-on:click="nuevo()" >Nuevo Empleado</button>
                <br><br>


                <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Nombre</th>
                        <th scope="col">CODIGO</th>
                        <th scope="col">TELEFONO</th>
                        <th scope="col">CORREO</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="empleado in ListaEmpleados" :key="empleado.idEmpleado" v-on:click="editar(empleado.idEmpleado)">
                        <th scope="row">{{ empleado.idEmpleado}}</th>
                        <td>{{ empleado.Nombre }}</td>
                        <td>{{ empleado.DNI }}</td>
                        <td>{{ empleado.Telefono }}</td>
                        <td>{{ empleado.Correo }}</td>
                    </tr>
            
                </tbody>
                </table>

            </div>

    </div>
</template>
<script>
import axios from 'axios';
export default {
    name:"Dashboard",
    data(){
        return {
            ListaEmpleados:null,
            pagina:1
        }
    },
    components:{
    },
    methods:{
            editar(id){
                this.$router.push('/editar/' + id);
            },
            nuevo(){
                this.$router.push('/nuevo');
            }
    },
    mounted:function(){
        let direccion = "https://localhost:7250/api/empleados" + this.pagina;
        axios.get(direccion).then( data =>{
            this.ListaEmpleados = data.data;
        });
    }
}
</script>
<style  scoped>
    .izquierda{
        text-align: left;
    }
</style>