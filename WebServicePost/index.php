<?php 

$jsonPost=file_get_contents("php://input");

$valuesPost= json_decode($jsonPost, true);


if (isset($valuesPost["IdEmpresa"])) {

	$IdEmpresa=$valuesPost["IdEmpresa"];
	$listEmpleados=array();

	switch ($IdEmpresa) {
		case 1:
			for ($i=0; $i < 5; $i++) { 
				$listEmpleados[$i]["IdEmpleado"]=$i;
				$listEmpleados[$i]["EmpNombre"]="Empleado ".$i." : empresa Proguer";
				$listEmpleados[$i]["EmpApellido"]="Apellido de empleado ".$i;
			}
			break;
		
		case 2:
			for ($i=0; $i < 3; $i++) { 
				$listEmpleados[$i]["IdEmpleado"]=$i;
				$listEmpleados[$i]["EmpNombre"]="Empleado ".$i." de la empresa OFMA";
				$listEmpleados[$i]["EmpApellido"]="Apellido de empleado ".$i;
			}
			break;
	}
	echo json_encode($listEmpleados);

}else{
	echo "";
}

 ?>