let colorMap = new Map();

colorMap.set('black',0);
colorMap.set('brown',1);
colorMap.set('red',2);
colorMap.set('orange',3);
colorMap.set('yellow',4);
colorMap.set('green',5);
colorMap.set('blue',6);
colorMap.set('violet',7);
colorMap.set('grey',8);
colorMap.set('white',9);

export const colorCode = (color) => {
  return colorMap.get(color);
};

export const COLORS = Array.from(colorMap.keys());
