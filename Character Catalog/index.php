<?php
  include('connect.php');
  $pdo = DBconnect('localhost', 'rubyquest', 'root', 'password');
  $countResult = queryHandling($pdo, "SELECT COUNT(`id`) AS count FROM `characters`", 0)->fetch(PDO::FETCH_ASSOC);
  $charNames = queryHandling($pdo, "SELECT `name` FROM `characters`", 0)->fetchAll(PDO::FETCH_COLUMN);
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>All Characters</title>
  <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
  <link href="resources/css/style.css" rel="stylesheet"/>
</head>
<body>
<header>
  <h1>Alle <?php echo $countResult['count']?> characters uit de database</h1>
</header>
<div id="container">
<?php 
foreach($charNames as $index => $curName) {
  $charData = queryHandling($pdo, "SELECT * FROM `characters` WHERE `name` = '" . $curName . "'", 0)->fetch(PDO::FETCH_ASSOC);
  echo '<a class="item" href="character.php?character=' . $charData['name'] . '">';
  echo '<div class="left">';
  echo '<img class="avatar" src="resources/images/' . $charData['avatar'] . '">';
  echo '</div>';
  echo '<div class="right">';
  echo '<h2>' . $charData['name'] . '</h2>';
  echo '<div class="stats">';
  echo '<ul class="fa-ul">';
  echo '<li><span class="fa-li"><i class="fas fa-heart"></i></span> ' . $charData['health'] . '</li>';
  echo '<li><span class="fa-li"><i class="fas fa-fist-raised"></i></span> ' . $charData['attack'] . '</li>';
  echo '<li><span class="fa-li"><i class="fas fa-shield-alt"></i></span> ' . $charData['defense'] . '</li>';
  echo '</ul>';
  echo '</div>';
  echo '</div>';
  echo '<div class="detailButton"><i class="fas fa-search"></i> bekijk</div>';
  echo '</a>';
}
$pdo = terminatePDO($pdo);
?>
</div>
<footer>&copy; Robin Vervoorn 2023</footer>
</body>
</html>