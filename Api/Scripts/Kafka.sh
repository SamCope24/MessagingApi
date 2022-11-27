docker exec broker \
kafka-topics --bootstrap-server broker:9092 \
--create \
--topic messages

kafka-console-producer --bootstrap-server broker:9092 \
--topic messages \

kafka-console-consumer --bootstrap-server broker:9092 \
--topic messages \
--from-beginning \