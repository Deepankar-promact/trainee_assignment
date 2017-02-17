<?php

function reverse($array){
	
	$len = count($array);
	$temp = 0;
	
	for($i = 0; $i < floor($len/2); $i++){
		$temp = $array[$i];
		$array[$i] = $array[$len-1-$i];
		$array[$len-1-$i] = $temp;
	}	
	
	return $array;
}

function displayArray($array){
	$len = count($array);
	
	for($i = 0; $i < $len; $i++){
		echo $array[$i]." "; 
	}	
}

$arrayLen = readline("Array length: ");

for($i =0; $i < $arrayLen; $i++)
	$arr[$i] = readline("Element ".($i+1).": "); 

displayArray(reverse($arr));

?>