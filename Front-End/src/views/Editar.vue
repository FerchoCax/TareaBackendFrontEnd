<template>
        <div>
            <div class="container">
                <form action="" class="form-horizontal">
                    <div class="form-group left">
                       <label for="" class="control-label col-sm-2">Nombre</label>
                       <div class="col-sm-10">
                          <input type="text" class="form-control" name="nombre" id="nombre" v-model="form.nombre">
                       </div>
                    </div>
                    <div class="form-group left">
                       <label for="" class="control-label col-sm-2">Direccion</label>
                       <div class="col-sm-10">
                          <input type="text" class="form-control" name="direccion" id="direccion" v-model="form.direccion">
                       </div>
                    </div>
                    <div class="form-group left row">
                      <div class="col">
                            <label for="" class="control-label col-sm-3">apellido</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control" name="correo" id="correo" v-model="form.correo">
                            </div>
                        </div>
                        <div class="col">
                          <label for="" class="control-label col-sm-5">codigo Postal</label>
                          <div class="col-sm-7">
                              <input type="text" class="form-control" name="codigopostal" id="codigopostal" v-model="form.codigoPostal">
                          </div>
                        </div> 
                    </div>
                    <div class="form-group left row">
                         <div class="col">
                            <label for="" class="control-label col-sm-2">Genero</label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control" name="genero" id="genero" v-model="form.genero">
                            </div>
                          </div>
                         <div class="col">
                              <label for="" class="control-label col-sm-2">Telefono</label>
                              <div class="col-sm-7">
                                  <input type="text" class="form-control" name="telefono" id="telefono" v-model="form.telefono">
                              </div>
                        </div>
                    </div>
                    <div class="form-group left">
                        <label for="" class="control-label col-sm-2">Fecha nacimiento</label>
                       <div class="col-sm-4">
                          <input type="text" class="form-control" name="fechanacimineto" id="telefono" v-model="form.fechaNacimiento">
                       </div>
                    </div>


                    <div class="form-group">
                      <button type="button" class="btn btn-primary" v-on:click="editar()" >Editar</button>
                      <button type="button" class="btn btn-danger margen" v-on:click="eliminar()" >Eliminar</button>
                      <button type="button" class="btn btn-dark margen" v-on:click="salir()"  >Salir</button>
                    </div> 
                </form>
            </div>
        </div>
    
</template>
<script>
import axios from 'axios';
export default {
  name:"Editar",
  components:{
  },
  data:function(){
    return {
        form:{
          "idEmpleado":"",
          "nombre" : "",
          "direccion": "", 
          "dni" : "",
          "correo":"",
          "codigoPostal" :"",
          "genero" : "",
          "telefono" : "",
          "fechaNacimiento" : ""
        }
    }
  },
  methods:{
      editar(){
          axios.put("https://localhost:7250/api/empleados",this.form)
          .then( data =>{
              console.log(data);
          })
      },
      salir(){
        this.$router.push("/");
      },
      eliminar(){
        var enviar = {
            "idEmpleado" : this.form.idEmpleado,
        };
        axios.delete("https://localhost:7250/api/empleados", { headers : enviar})
        .then( datos => {
            console.log(datos);
           this.$router.push("/");
        });

      }
  },
  mounted:function(){
      this.form.idEmpleado = this.$route.params.id;
      axios.get("https://localhost:7250/api/empleados"+ this.form.idEmpleado)
      .then( datos => {
        
        this.form.nombre = datos.data[0].Nombre;
        this.form.direccion = datos.data[0].Direccion;
        this.form.dni = datos.data[0].DNI;
        this.form.correo = datos.data[0].Correo;
        this.form.codigoPostal = datos.data[0].CodigoPostal;
        this.form.genero = datos.data[0].Genero;
        this.form.telefono = datos.data[0].Telefono;
        this.form.fechaNacimiento = datos.data[0].FechaNacimiento;
        console.log(this.form);

      })
     
  }  
}
</script>
<style scoped>
 .left{
   text-align: left;
 };
 .margen{
   margin-left: 15px;
   margin-right: 15px;;
 }
</style>