<?php
  include('connect.php');
  $curChar = $_GET['character'];
  if ($curChar) {
    $pdo = DBconnect('localhost', 'rubyquest', 'root', 'password');
    $charNames = queryHandling($pdo, "SELECT `name` FROM `characters`", 0)->fetchAll(PDO::FETCH_COLUMN);
    if (in_array($curChar, array_values($charNames))) {
      $charData = queryHandling($pdo, "SELECT * FROM `characters` WHERE `name`='" . $curChar . "'", 0)->fetch(PDO::FETCH_ASSOC);
    } else {
      echo 'INVALID CHARACTER!!!';
      die();
    }
    terminatePDO($pdo);
  }
?>
<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Character - <?php echo $charData['name']?></title>
  <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr" crossorigin="anonymous">
  <link href="resources/css/style.css" rel="stylesheet"/>
</head>
<body>
<header>
  <h1><?php echo $charData['name']?></h1>
  <a class="backbutton" href="index.php"><i class="fas fa-long-arrow-alt-left"></i> Terug</a>
</header>
<div id="container">
  <div class="detail">
    <div class="left">
      <img class="avatar" src="resources/images/<?php echo $charData['avatar']?>">
      <div class="stats" style="background-color: <?php echo $charData['color']?>">
        <ul class="fa-ul">
          <li><span class="fa-li"><i class="fas fa-heart"></i></span> <?php echo $charData['health']?></li>
          <li><span class="fa-li"><i class="fas fa-fist-raised"></i></span> <?php echo $charData['attack']?></li>
          <li><span class="fa-li"><i class="fas fa-shield-alt"></i></span> <?php echo $charData['defense']?></li>
        </ul>
        <ul class="gear">
          <?php
            if ($charData['weapon']) {
              echo "<li><b>Weapon</b>: " . $charData['weapon'] . "</li>";
            }
            if ($charData['armor']) {
              echo "<li><b>Armor</b>: " . $charData['armor'] . "</li>";
            }     
          ?>
        </ul>
      </div>
    </div>
    <div class="right">
      <p><?php echo $charData['bio']?></p>
    </div>
    <div style="clear: both"></div>
  </div>
</div>
<footer>&copy; Robin Vervoorn 2023</footer>
</body>
</html>