<?php
function drawPattern($rows){
	$i = 0;
	$j = 0;
	
	$rows += $rows - 1; 
	
	$stars = 1;
	$spaces = floor($rows/2);
	$spaceModifier = -1;
	$starModifier = 0;
	
	
	
	for($i = 0;$i < $rows; $i++){
		for($j = $spaces;$j > 0; $j--){
			echo " ";
		}
		
		for($j = 0;$j < $stars + $starModifier; $j++){
			echo "*";
		}
		
		
		
		
		if($i < floor($rows/2)){
			$spaces--;
			$stars++;
			$starModifier++;
		}
		else{
			$spaces++;
			$stars--;
			$starModifier--;
		}
		
		echo "\n";
		
	}
	
	
		
}
drawPattern(4);
echo "HELLO";
?>